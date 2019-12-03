package com.example.sigloxxi.model;

import java.util.List;

public class OrdenH
{
    private int id;
    private int total;
    private int estado;
    private List<OrdenB> ordenBId;
    private Mesa mesaId;
    private int documentoId;



    public OrdenH(int total, int estado, List<OrdenB> ordenBId, Mesa mesaId) {
        this.total = total;
        this.estado = estado;
        this.ordenBId = ordenBId;
        this.mesaId = mesaId;
    }

    public OrdenH(int id, int total, int estado, int documentoId) {
        this.total = total;
        this.estado = estado;
        this.id = id;
        this.documentoId = documentoId;
    }

    public OrdenH() {

    }

    public int getDocumentoId() { return documentoId; }

    public void setDocumentoId(int documentoId) { this.documentoId = documentoId; }

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

    public int existeOrdenBConCiertoPlatillo(int id)
    {
        for (OrdenB od: ordenBId ) {
            if(od.getPlatilloId().getId() == id)
            {
                return 1;
            }
        }
        return 0;
    }

    public OrdenB OrdenBByIdConCiertoPlatillo(int id)
    {
        for (OrdenB od: ordenBId ) {
            if(od.getPlatilloId().getId() == id)
            {
                return od;
            }
        }
        return new OrdenB();
    }



}
