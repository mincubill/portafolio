package com.example.sigloxxi.service;

import com.example.sigloxxi.model.Platillo;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface iPlatillo
{
    @GET("/platillos/obtener-platillos")
    Call<List<Platillo>> getPlatillos();
}

