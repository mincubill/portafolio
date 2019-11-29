package com.example.sigloxxi.service;

import com.example.sigloxxi.model.OrdenB;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface iOrdenB
{
    @PUT("/ordenb/actualizar-ordenb/{id}")
    Call<OrdenB> actualizarOrdenB(@Path("id") int id, @Body OrdenB ordenB);

    @POST("/ordenb/crear-ordenb")
    Call<OrdenB> crearOrdenB(@Body OrdenB ordenB);
}
