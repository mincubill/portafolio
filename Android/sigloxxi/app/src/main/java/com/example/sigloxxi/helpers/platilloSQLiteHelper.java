package com.example.sigloxxi.helpers;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.sigloxxi.model.Platillo;

import java.util.ArrayList;
import java.util.List;

public class platilloSQLiteHelper extends SQLiteOpenHelper
{
    String sqlCreate = "CREATE TABLE Platillo (ID INTEGER PRIMARY KEY  NOT NULL,NOMBRE TEXT,TIEMPO INTEGER,PRECIO INTEGER)";

    public platilloSQLiteHelper(Context contex,String name,SQLiteDatabase.CursorFactory factory,int version)
    {
        super(contex,name,factory,version);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(sqlCreate);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS Platillo");
        db.execSQL(sqlCreate);
    }

    public  List<Platillo> getAllPlatillos(SQLiteDatabase db)
    {
        Cursor cursor = db.rawQuery("SELECT * FROM Platillo",null);
        List<Platillo> list = new ArrayList<Platillo>();
        if(cursor.moveToFirst()){
            while(cursor.isAfterLast()== false){
                int id = cursor.getInt(cursor.getColumnIndex("ID"));
                String nombre = cursor.getString(cursor.getColumnIndex("NOMBRE"));
                int tiempo = cursor.getInt(cursor.getColumnIndex("TIEMPO"));
                int precio = cursor.getInt(cursor.getColumnIndex("PRECIO"));
                list.add(new Platillo(id,nombre,tiempo,precio));
                cursor.moveToNext();

            }
        }
        return list;
    }

    public void insertPlatillo (Platillo pla,SQLiteDatabase db)
    {
        ContentValues nuevo_registro = new ContentValues();
        nuevo_registro.put("ID",pla.getId());
        nuevo_registro.put("NOMBRE",pla.getNombre());
        nuevo_registro.put("TIEMPO",pla.getTiempo());
        nuevo_registro.put("PRECIO",pla.getPrecio());
        db.insert("Platillo",null,nuevo_registro);
    }

    public void deletePlatillo (SQLiteDatabase db)
    {
        db.execSQL("DELETE FROM Platillo");
    }
}
