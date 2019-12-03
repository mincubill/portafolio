package com.example.sigloxxi.model;

public class OrdenB
{

    private int id;
    private int cantidad;
    private int subtotal;
    private Platillo platilloId;
    private int ordenHId;



    public OrdenB(int cantidad, int subtotal, Platillo platilloId) {
        this.cantidad = cantidad;
        this.subtotal = subtotal;
        this.platilloId = platilloId;
    }

    public OrdenB(int cantidad, int subtotal, Platillo platilloId,int ordenHId) {
        this.cantidad = cantidad;
        this.subtotal = subtotal;
        this.platilloId = platilloId;
        this.ordenHId = ordenHId;
    }

    public OrdenB() {

    }

    public int getOrdenHId() { return ordenHId; }

    public void setOrdenHId(int ordenHId) { this.ordenHId = ordenHId; }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public int getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(int subtotal) {
        this.subtotal = subtotal;
    }

    public Platillo getPlatilloId() {
        return platilloId;
    }

    public void setPlatilloId(Platillo platilloId) {
        this.platilloId = platilloId;
    }


}
