package com.example.sigloxxi.model;

public class Carrito
{
    private int platilloID;
    private int cantidad;
    private String nombre;

    public Carrito(int platilloID, int cantidad,String nombre) {
        this.platilloID = platilloID;
        this.cantidad = cantidad;
        this.nombre = nombre;
    }

    public String getNombre() { return nombre; }

    public void setNombre(String nombre) { this.nombre = nombre; }

    public int getPlatilloID() {
        return platilloID;
    }

    public void setPlatilloID(int platilloID) {
        this.platilloID = platilloID;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }



}
