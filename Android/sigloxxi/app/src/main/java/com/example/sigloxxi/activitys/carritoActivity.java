package com.example.sigloxxi.activitys;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.example.sigloxxi.R;
import com.example.sigloxxi.adapters.PedidoAdapter;
import com.example.sigloxxi.helpers.OrdenHIdSQLiteHelper;
import com.example.sigloxxi.helpers.ServiceGenerator;
import com.example.sigloxxi.helpers.carritoSQLiteHelper;
import com.example.sigloxxi.helpers.platilloSQLiteHelper;
import com.example.sigloxxi.model.Carrito;
import com.example.sigloxxi.model.Documento;
import com.example.sigloxxi.model.Mesa;
import com.example.sigloxxi.model.OrdenB;
import com.example.sigloxxi.model.OrdenH;
import com.example.sigloxxi.model.PedidoH;
import com.example.sigloxxi.model.Platillo;
import com.example.sigloxxi.model.Token;
import com.example.sigloxxi.service.iDocumento;
import com.example.sigloxxi.service.iOrdenB;
import com.example.sigloxxi.service.iOrdenH;
import com.example.sigloxxi.service.iToken;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class carritoActivity extends AppCompatActivity {

    private ArrayList<Platillo> platillos = new ArrayList<Platillo>();
    private ArrayList<Carrito>  carrito = new ArrayList<Carrito>();
    private SQLiteDatabase db;
    private SQLiteDatabase db1;
    private SQLiteDatabase db2;
    private ListView lv;
    private Button btn;
    private Button btnPedirExtra;
    private Button btnBoleta;
    private Token tokenKey = new Token();
    private int ordenHId;
    private int subtotalTemporal;
    private OrdenH ordenHAnterior = new OrdenH();

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_carrito);
        // base de datos sqlite
        final platilloSQLiteHelper plaSQLiteHelper = new platilloSQLiteHelper(this,"dbtest",null,1);
        db = plaSQLiteHelper.getWritableDatabase();
        final carritoSQLiteHelper caSQLitehelper = new carritoSQLiteHelper(this,"dbtest1",null,1);
        db1 = caSQLitehelper.getWritableDatabase();
        final OrdenHIdSQLiteHelper ordenSQLiteHelper = new OrdenHIdSQLiteHelper(this, "dbtest3",null,1);
        db2 = ordenSQLiteHelper.getWritableDatabase();

        platillos.addAll(plaSQLiteHelper.getAllPlatillos(db));
        carrito.addAll(caSQLitehelper.getAllCarrito(db1));

        btn = findViewById(R.id.button2);
        btnPedirExtra = findViewById(R.id.button3);
        btnBoleta = findViewById(R.id.button4);

        if(carrito.size()==0)
        {
            btn.setEnabled(false);
            btnBoleta.setEnabled(false);
            btnPedirExtra.setEnabled(false);
        }
        else{
            btn.setEnabled(true);
            btnBoleta.setEnabled(true);
            btnPedirExtra.setEnabled(false);
        }

        if (ordenSQLiteHelper.getAllOrdenHId(db2).size()==1)
        {
            btnBoleta.setEnabled(true);

        }
        else{
            btnBoleta.setEnabled(false);
        }
        btn.setOnClickListener(new View.OnClickListener()
        {
            @RequiresApi(api = Build.VERSION_CODES.N)
            @Override
            public void onClick(View v) {

                if(ordenSQLiteHelper.getAllOrdenHId(db2).size()==1){
                    ordenHId = ordenSQLiteHelper.getAllOrdenHId(db2).get(0);
                    final iToken tk = ServiceGenerator.createService(iToken.class,".net","123");
                    Call<Token> tokenCall = tk.getToken("FINANZAS","ASDF","password");
                    tokenCall.enqueue(new Callback<Token>() {
                        @Override
                        public void onResponse(Call<Token> call, Response<Token> response)
                        {
                            if(response.code()==200){
                                tokenKey.setAccess_token(response.body().getAccess_token());
                                tokenKey.setExpires_in(response.body().getExpires_in());
                                tokenKey.setRefresh_token(response.body().getRefresh_token());
                                tokenKey.setJti(response.body().getJti());

                            }
                            System.out.println(response.body().getAccess_token());
                        }

                        @Override
                        public void onFailure(Call<Token> call, Throwable t) {
                            System.out.println(t.getMessage());
                        }
                    });

                    final iOrdenH odh = new ServiceGenerator().createService(iOrdenH.class,tokenKey.getAccess_token());
                    Call<OrdenH> OrdenHCall = odh.getOrdenHById(ordenHId);
                    OrdenHCall.enqueue(new Callback<OrdenH>() {
                        @Override
                        public void onResponse(Call<OrdenH> call, Response<OrdenH> response) {
                           ordenHAnterior.setEstado(response.body().getEstado());
                           ordenHAnterior.setId(response.body().getId());
                           ordenHAnterior.setMesaId(response.body().getMesaId());
                           ordenHAnterior.setOrdenBId(response.body().getOrdenBId());
                           ordenHAnterior.setTotal(response.body().getTotal());
                           ordenHAnterior.setDocumentoId(response.body().getDocumentoId());
                           subtotalTemporal= ordenHAnterior.getTotal();
                            for (Carrito ca: carrito)
                            {

                                if ( ordenHAnterior.existeOrdenBConCiertoPlatillo(ca.getPlatilloID())== 1)
                                {
                                    OrdenB od = ordenHAnterior.OrdenBByIdConCiertoPlatillo(ca.getPlatilloID());
                                    od.setCantidad(od.getCantidad()+ca.getCantidad());
                                    od.setSubtotal(od.getSubtotal()+(ca.getCantidad()*buscaplatillo(platillos,ca.getPlatilloID()).getPrecio()));
                                    subtotalTemporal= subtotalTemporal+(ca.getCantidad()*buscaplatillo(platillos,ca.getPlatilloID()).getPrecio());
                                    final iOrdenB odb = new ServiceGenerator().createService(iOrdenB.class,tokenKey.getAccess_token());
                                    Call<OrdenB> OrdenBCall = odb.actualizarOrdenB(od.getId(),od);
                                    OrdenBCall.enqueue(new Callback<OrdenB>() {
                                        @Override
                                        public void onResponse(Call<OrdenB> call, Response<OrdenB> response) {
                                            response.body();
                                        }

                                        @Override
                                        public void onFailure(Call<OrdenB> call, Throwable t) {

                                        }
                                    });
                                }
                                else{
                                    OrdenB ordenBnueva = new OrdenB(ca.getCantidad(),(ca.getCantidad()*buscaplatillo(platillos,ca.getPlatilloID()).getPrecio()),buscaplatillo(platillos,ca.getPlatilloID()),ordenHId);
                                    subtotalTemporal= subtotalTemporal+(ordenBnueva.getCantidad()*ordenBnueva.getPlatilloId().getPrecio());
                                    final iOrdenB odb = new ServiceGenerator().createService(iOrdenB.class,tokenKey.getAccess_token());
                                    Call<OrdenB> ordenBCall =  odb.crearOrdenB(ordenBnueva);
                                    ordenBCall.enqueue(new Callback<OrdenB>() {
                                        @Override
                                        public void onResponse(Call<OrdenB> call, Response<OrdenB> response) {
                                            response.body();
                                            System.out.println();
                                        }

                                        @Override
                                        public void onFailure(Call<OrdenB> call, Throwable t) {

                                        }
                                    });
                                }
                            }
                            OrdenH ordenHatualizar = new OrdenH(ordenHAnterior.getId(),subtotalTemporal,ordenHAnterior.getEstado(),ordenHAnterior.getDocumentoId());
                            final iOrdenH odh1 = new ServiceGenerator().createService(iOrdenH.class,tokenKey.getAccess_token());
                            Call<OrdenH> OrdenHCall1 = odh1.actualizarOrdenH(ordenHId,ordenHatualizar);
                            OrdenHCall1.enqueue(new Callback<OrdenH>() {
                                @Override
                                public void onResponse(Call<OrdenH> call, Response<OrdenH> response) {
                                    response.body();
                                }

                                @Override
                                public void onFailure(Call<OrdenH> call, Throwable t) {

                                }
                            });
                        }

                        @Override
                        public void onFailure(Call<OrdenH> call, Throwable t) {

                        }
                    });
                    Toast.makeText(carritoActivity.this,"se a agregado a su pedido",Toast.LENGTH_SHORT).show();
                    btn.setEnabled(false);
                    btnPedirExtra.setEnabled(true);


                }else {


                    ArrayList<OrdenB> ordenBody = new ArrayList<OrdenB>();
                    int total = 0;
                    for (Carrito ca:carrito)
                    {
                        Platillo plaTemporal = buscaplatillo(platillos,ca.getPlatilloID());
                        int subtotal = ca.getCantidad()*plaTemporal.getPrecio() ;
                        ordenBody.add(new OrdenB(ca.getCantidad(),subtotal,plaTemporal));
                        total+=subtotal;
                    }
                    final OrdenH ordenHeader = new OrdenH(total,1,ordenBody,new Mesa(1,1,2));
                    ArrayList<OrdenH> ordenList = new ArrayList<OrdenH>(){{add(ordenHeader);}};
                    ArrayList<PedidoH> pedidoList = new ArrayList<PedidoH>();
                    Date fecha = new Date();
                    DecimalFormat format = new DecimalFormat("00");
                    String fechaTemporal =  Calendar.getInstance().get(Calendar.YEAR)+"-"+(Calendar.getInstance().get(Calendar.MONTH)+1)+"-"+format.format(Calendar.getInstance().get(Calendar.DATE));
                    String horaTemporal = Calendar.getInstance().get(Calendar.HOUR)+":"+Calendar.getInstance().get(Calendar.MINUTE);
                    Documento documento = new Documento(0,fechaTemporal,horaTemporal,1,ordenList,pedidoList);


                    final iToken tk = ServiceGenerator.createService(iToken.class,".net","123");
                    Call<Token> tokenCall = tk.getToken("FINANZAS","ASDF","password");
                    tokenCall.enqueue(new Callback<Token>() {
                        @Override
                        public void onResponse(Call<Token> call, Response<Token> response)
                        {
                            if(response.code()==200){
                                tokenKey.setAccess_token(response.body().getAccess_token());
                                tokenKey.setExpires_in(response.body().getExpires_in());
                                tokenKey.setRefresh_token(response.body().getRefresh_token());
                                tokenKey.setJti(response.body().getJti());

                            }
                            System.out.println(response.body().getAccess_token());
                        }

                        @Override
                        public void onFailure(Call<Token> call, Throwable t) {
                            System.out.println(t.getMessage());
                        }
                    });




                    iDocumento documentoService = ServiceGenerator.createService(iDocumento.class,tokenKey.getAccess_token());
                    Call<Documento> documentoCall = documentoService.createDocumento(documento);
                    documentoCall.enqueue(new Callback<Documento>() {
                        @Override
                        public void onResponse(Call<Documento> call, Response<Documento> response) {
                            System.out.println(response);
                            if(response.code()==201)
                            {
                                System.out.println(response.body());
                                ordenHId= response.body().getOrdenHId().get(0).getId();

                                caSQLitehelper.carritoDelete(db1);
                                Toast.makeText(carritoActivity.this,"orden realizada con exito",Toast.LENGTH_SHORT).show();
                            }
                        }

                        @Override
                        public void onFailure(Call<Documento> call, Throwable t) {
                            System.out.println(t.getMessage());
                        }
                    });
                    btn.setEnabled(false);
                    btnPedirExtra.setEnabled(true);
                    btnBoleta.setEnabled(true);
                }


            }
        }) ;

        btnPedirExtra.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                ordenSQLiteHelper.DeleteOrdenHId(db2);
                ordenSQLiteHelper.insertOrdenHId(ordenHId,db2);
                btn.setEnabled(true);
                Intent intent = new Intent (v.getContext(), MainActivity.class);
                startActivityForResult(intent, 0);
            }
        });

        btnBoleta.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                ordenSQLiteHelper.DeleteOrdenHId(db2);
                Toast.makeText(carritoActivity.this, "para cancelar acerquese a la caja Gracias por preferirnos", Toast.LENGTH_LONG).show();
                Intent intent = new Intent (v.getContext(), MainActivity.class);
                startActivityForResult(intent, 0);
            }
        });

        lv = (ListView) findViewById(R.id.ListView2);
        PedidoAdapter pedidoAdapter = new PedidoAdapter(this,R.layout.pedido,carrito);
        lv.setAdapter(pedidoAdapter);
    }

    public Platillo buscaplatillo (ArrayList<Platillo> pla, int idplatillo)
    {
        for (Platillo pa: pla)
        {
            if(pa.getId()==idplatillo)
                return pa;
        }
        return new Platillo();
    }
}
