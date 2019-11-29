package com.example.sigloxxi.service;

import com.example.sigloxxi.model.OrdenH;
import com.example.sigloxxi.model.Platillo;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface iOrdenH {
    @GET("/ordenh/buscar-ordenh/{id}")
    Call <OrdenH>  getOrdenHById(@Path("id") int id);

    @PUT("/ordenh/actualizar-ordenh/{id}")
    Call<OrdenH> actualizarOrdenH(@Path("id") int id,@Body OrdenH ordenH);
}
