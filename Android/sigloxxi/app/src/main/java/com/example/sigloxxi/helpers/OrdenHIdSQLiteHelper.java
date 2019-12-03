package com.example.sigloxxi.helpers;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.sigloxxi.model.Carrito;

import java.util.ArrayList;
import java.util.List;

public class OrdenHIdSQLiteHelper extends SQLiteOpenHelper
{
    String sqlCreate = "CREATE TABLE ordenHId (ORDENHID INTEGER)";

    public OrdenHIdSQLiteHelper(Context contex, String name, SQLiteDatabase.CursorFactory factory, int version)
    {
        super(contex,name,factory,version);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {
        db.execSQL(sqlCreate);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
        db.execSQL("DROP TABLE IF EXISTS ordenHId");
        db.execSQL(sqlCreate);
    }

    public void insertOrdenHId (int ordenHID, SQLiteDatabase db)
    {
        ContentValues nuevo_registro = new ContentValues();
        nuevo_registro.put("ORDENHID",ordenHID);
        db.insert("ordenHId",null,nuevo_registro);
    }

    public List<Integer> getAllOrdenHId(SQLiteDatabase db)
    {
        if(db!= null){
            Cursor cursor = db.rawQuery("SELECT * FROM ordenHId",null);
            List<Integer> list = new ArrayList<Integer>();
            if(cursor.moveToFirst()){
                while(cursor.isAfterLast()== false){
                    int id = cursor.getInt(cursor.getColumnIndex("ORDENHID"));


                    list.add(id);
                    cursor.moveToNext();

                }
            }
            return list;
        }else{
            return new ArrayList<Integer>();
        }
    }

    public void DeleteOrdenHId(SQLiteDatabase db)
    {
        db.execSQL("DELETE FROM ordenHId");
    }
}
