package com.example.sigloxxi.model;

import java.util.Date;
import java.util.List;

public class Documento
{

    private int id;
    private String fecha;
    private String hora;
    private int tipo;

    public Documento(int id, String fecha, String hora, int tipo, List<OrdenH> ordenHId, List<PedidoH> pedidoH) {
        this.id = id;
        this.fecha = fecha;
        this.hora = hora;
        this.tipo = tipo;
        this.ordenHId = ordenHId;
        this.pedidoH = pedidoH;
    }

    private List<OrdenH> ordenHId;
    private List<PedidoH> pedidoH;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public String getHora() {
        return hora;
    }

    public void setHora(String hora) {
        this.hora = hora;
    }

    public int getTipo() {
        return tipo;
    }

    public void setTipo(int tipo) {
        this.tipo = tipo;
    }

    public List<OrdenH> getOrdenHId() {
        return ordenHId;
    }

    public void setOrdenHId(List<OrdenH> ordenHId) {
        this.ordenHId = ordenHId;
    }

    public List<PedidoH> getPedidoH() {
        return pedidoH;
    }

    public void setPedidoH(List<PedidoH> pedidoH) {
        this.pedidoH = pedidoH;
    }
}
