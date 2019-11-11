package com.example.sigloxxi.activitys;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.database.sqlite.SQLiteDatabase;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.example.sigloxxi.R;
import com.example.sigloxxi.adapters.PedidoAdapter;
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
import com.example.sigloxxi.service.iToken;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.stream.IntStream;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class carritoActivity extends AppCompatActivity {

    private ArrayList<Platillo> platillos = new ArrayList<Platillo>();
    private ArrayList<Carrito>  carrito = new ArrayList<Carrito>();
    private SQLiteDatabase db;
    private SQLiteDatabase db1;
    private ListView lv;
    private Button btn;
    private Token tokenKey = new Token();

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

        platillos.addAll(plaSQLiteHelper.getAllPlatillos(db));
        carrito.addAll(caSQLitehelper.getAllCarrito(db1));

        btn = findViewById(R.id.button2);
        btn.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.N)
            @Override
            public void onClick(View v) {
                Toast.makeText(carritoActivity.this,"wenda ",Toast.LENGTH_SHORT).show();
                ArrayList<OrdenB> ordenBody = new ArrayList<OrdenB>();
                int total = 0;
                for (Carrito ca:carrito)
                {
                    Platillo plaTemporal = buscaplatillo(platillos,ca.getPlatilloID());
                    //int subtotal = ca.getCantidad()*platillos.get(ca.getPlatilloID()-1).getPrecio();
                    int subtotal = ca.getCantidad()*plaTemporal.getPrecio() ;
                    ordenBody.add(new OrdenB(ca.getCantidad(),subtotal,plaTemporal));
                    total+=subtotal;
                }
                final OrdenH ordenHeader = new OrdenH(total,2,ordenBody,new Mesa(1,1,2));
                ArrayList<OrdenH> ordenList = new ArrayList<OrdenH>(){{add(ordenHeader);}};
                ArrayList<PedidoH> pedidoList = new ArrayList<PedidoH>();
                Date fecha = new Date();
                String fechaTemporal =  Calendar.getInstance().get(Calendar.YEAR)+"-"+(Calendar.getInstance().get(Calendar.MONTH)+1)+"-"+Calendar.getInstance().get(Calendar.DATE);
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
                        }
                    }

                    @Override
                    public void onFailure(Call<Documento> call, Throwable t) {
                        System.out.println(t.getMessage());
                    }
                });
                System.out.println("hola");
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
