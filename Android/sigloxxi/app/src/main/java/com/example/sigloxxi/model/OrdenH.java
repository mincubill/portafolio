package com.example.sigloxxi.model;

import java.util.List;

public class OrdenH
{
    private int id;
    private int total;
    private int estado;
    private List<OrdenB> ordenBId;
    private Mesa mesaId;

    public OrdenH(int total, int estado, List<OrdenB> ordenBId, Mesa mesaId) {
        this.total = total;
        this.estado = estado;
        this.ordenBId = ordenBId;
        this.mesaId = mesaId;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getTotal() {
        return total;
    }

    public void setTotal(int total) {
        this.total = total;
    }

    public int getEstado() {
        return estado;
    }

    public void setEstado(int estado) {
        this.estado = estado;
    }

    public List<OrdenB> getOrdenBId() {
        return ordenBId;
    }

    public void setOrdenBId(List<OrdenB> ordenBId) {
        this.ordenBId = ordenBId;
    }

    public Mesa getMesaId() {
        return mesaId;
    }

    public void setMesaId(Mesa mesaId) {
        this.mesaId = mesaId;
    }


}
