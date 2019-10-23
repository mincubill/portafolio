package com.example.sigloxxi.helpers;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.sigloxxi.model.Carrito;
import com.example.sigloxxi.model.Platillo;

import java.util.ArrayList;
import java.util.List;

public class carritoSQLiteHelper extends SQLiteOpenHelper
{
   String sqlCreate = "CREATE TABLE Carrito (PLATILLOID INTEGER,CANTIDAD INTEGER,NOMBRE TEXT)";

   public carritoSQLiteHelper(Context contex, String name, SQLiteDatabase.CursorFactory factory, int version)
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

    public void insertCarrito (Platillo pla,int cantidad,SQLiteDatabase db)
    {
        ContentValues nuevo_registro = new ContentValues();
        nuevo_registro.put("PLATILLOID",pla.getId());
        nuevo_registro.put("CANTIDAD",cantidad);
        nuevo_registro.put("NOMBRE",pla.getNombre());
        db.insert("Carrito",null,nuevo_registro);
    }

    public void updateCarrito(SQLiteDatabase db,int id)
    {
        String sql="UPDATE Carrito set CANTIDAD = CANTIDAD+1 WHERE PLATILLOID ="+id;
        db.execSQL(sql);
    }

    public List<Carrito> getAllCarrito(SQLiteDatabase db)
    {
        if(db!= null){
            Cursor cursor = db.rawQuery("SELECT * FROM Carrito",null);
            List<Carrito> list = new ArrayList<Carrito>();
            if(cursor.moveToFirst()){
                while(cursor.isAfterLast()== false){
                    int id = cursor.getInt(cursor.getColumnIndex("PLATILLOID"));
                    int cantidad = cursor.getInt(cursor.getColumnIndex("CANTIDAD"));
                    String nombre = cursor.getString(cursor.getColumnIndex("NOMBRE"));

                    list.add(new Carrito(id,cantidad,nombre));
                    cursor.moveToNext();

                }
            }
            return list;
        }else{
            return new ArrayList<Carrito>();
        }
    }

    public int existeCarrito(int id,SQLiteDatabase db)
    {
        List<Carrito> carrito = getAllCarrito(db);
        for (Carrito ca: carrito)
        {
            if(ca.getPlatilloID() == id){
                return 1;
            }
        }
        return 0;
    }

    public void carritoDelete(SQLiteDatabase db)
    {
        db.execSQL("DELETE FROM Carrito");
    }
}
