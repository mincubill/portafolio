package com.example.sigloxxi.activitys;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.Toast;

import com.example.sigloxxi.R;
import com.example.sigloxxi.adapters.BoletaAdapter;
import com.example.sigloxxi.adapters.PedidoAdapter;
import com.example.sigloxxi.helpers.OrdenHIdSQLiteHelper;
import com.example.sigloxxi.helpers.ServiceGenerator;
import com.example.sigloxxi.model.OrdenH;
import com.example.sigloxxi.model.Token;
import com.example.sigloxxi.service.iOrdenH;
import com.example.sigloxxi.service.iToken;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class BoletaActivity extends AppCompatActivity {


    private ImageView imageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_boleta);

        Toast.makeText(this, "para cancelar acerquese a la caja", Toast.LENGTH_SHORT).show();



    }
}
