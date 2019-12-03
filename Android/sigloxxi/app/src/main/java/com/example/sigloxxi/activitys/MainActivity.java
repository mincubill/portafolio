package com.example.sigloxxi.activitys;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.example.sigloxxi.R;
import com.example.sigloxxi.adapters.PlatilloAdapter;
import com.example.sigloxxi.helpers.OrdenHIdSQLiteHelper;
import com.example.sigloxxi.helpers.ServiceGenerator;
import com.example.sigloxxi.helpers.carritoSQLiteHelper;
import com.example.sigloxxi.helpers.platilloSQLiteHelper;
import com.example.sigloxxi.model.Platillo;
import com.example.sigloxxi.model.Token;
import com.example.sigloxxi.service.iPlatillo;
import com.example.sigloxxi.service.iToken;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    //variables
    private ListView lv;
    private Token tokenKey = new Token();
    private ArrayList<Platillo> platillos = new ArrayList<Platillo>();
    private SQLiteDatabase db;
    private SQLiteDatabase db1;
    private SQLiteDatabase db2;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        lv = (ListView) findViewById(R.id.ListView);
        final platilloSQLiteHelper plaSQLiteHelper = new platilloSQLiteHelper(this,"dbtest",null,1);
        db = plaSQLiteHelper.getWritableDatabase();
        final carritoSQLiteHelper caSQLiteHelper = new carritoSQLiteHelper(this,"dbtest1",null,1);
        db1 = caSQLiteHelper.getWritableDatabase();
        final OrdenHIdSQLiteHelper ordenSQLiteHelper = new OrdenHIdSQLiteHelper(this, "dbtest3",null,1);
        db2 = ordenSQLiteHelper.getWritableDatabase();


        if(tokenKey.getAccess_token() == null)
        {
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
        }

        if(plaSQLiteHelper.getAllPlatillos(db).size() == 0)
        {
            final iPlatillo pl = ServiceGenerator.createService(iPlatillo.class,tokenKey.getAccess_token());
            Call<List<Platillo>> platilloCall = pl.getPlatillos();
            platilloCall.enqueue(new Callback<List<Platillo>>() {
                @Override
                public void onResponse(Call<List<Platillo>> call, Response<List<Platillo>> response)
                {
                    if(response.code()==200)
                    {
                        for(Platillo pla : response.body())
                        {
                            if(db!=null)
                            {
                                plaSQLiteHelper.insertPlatillo(pla,db);
                            }
                        }
                    }
                }

                @Override
                public void onFailure(Call<List<Platillo>> call, Throwable t)
                {
                    System.out.println(t.getMessage());
                }
            });

            platillos.addAll(plaSQLiteHelper.getAllPlatillos(db));
        }else{
            platillos.addAll(plaSQLiteHelper.getAllPlatillos(db));
        }


        //agregamos la acion para poder redirijir a la otra activity
        Button btn = (Button) findViewById(R.id.button);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent (v.getContext(), carritoActivity.class);
                startActivityForResult(intent, 0);
            }
        });

        PlatilloAdapter Adapter1 = new PlatilloAdapter(this,R.layout.platillo_layout,platillos);

        lv.setAdapter(Adapter1);
        caSQLiteHelper.carritoDelete(db1);

    }

    @Override
    protected void onDestroy() {
        db1.close();
        db.close();
        super.onDestroy();
    }

    @Override
    protected void onStart() {
        super.onStart();
    }

    @Override
    protected void onStop() {
        super.onStop();
    }
}



