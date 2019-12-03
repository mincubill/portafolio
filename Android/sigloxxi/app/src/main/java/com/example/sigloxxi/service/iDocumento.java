package com.example.sigloxxi.service;

import com.example.sigloxxi.model.Documento;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface iDocumento
{
    @POST("/documentos/crear-documento")
    Call<Documento> createDocumento(@Body Documento documento);
}
