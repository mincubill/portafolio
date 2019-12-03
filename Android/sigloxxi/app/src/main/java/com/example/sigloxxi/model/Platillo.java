package com.example.sigloxxi.model;

import android.os.Parcel;
import android.os.Parcelable;

public class Platillo  implements android.os.Parcelable {
    private int id;
    private String nombre;
    private int tiempo;
    private int precio;

    public Platillo(int id, String nombre, int tiempo, int precio) {
        this.id = id;
        this.nombre = nombre;
        this.tiempo = tiempo;
        this.precio = precio;
    }

    public Platillo() {

    }

    protected Platillo(Parcel in) {
        id = in.readInt();
        nombre = in.readString();
        tiempo = in.readInt();
        precio = in.readInt();
    }

    public static final Creator<Platillo> CREATOR = new Creator<Platillo>() {
        @Override
        public Platillo createFromParcel(Parcel in) {
            return new Platillo(in);
        }

        @Override
        public Platillo[] newArray(int size) {
            return new Platillo[size];
        }
    };

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getTiempo() {
        return tiempo;
    }

    public void setTiempo(int tiempo) {
        this.tiempo = tiempo;
    }

    public int getPrecio() {
        return precio;
    }

    public void setPrecio(int precio) {
        this.precio = precio;
    }


    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(id);
        dest.writeInt(tiempo);
        dest.writeInt(precio);
        dest.writeString(nombre);
    }
}
