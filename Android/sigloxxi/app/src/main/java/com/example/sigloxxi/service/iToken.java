package com.example.sigloxxi.service;

import com.example.sigloxxi.model.Token;

import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.POST;

public interface iToken
{
    @FormUrlEncoded
    @POST("/oauth/token")
    Call<Token> getToken(@Field("username")String username, @Field("password")String password, @Field("grant_type")String grant_type);
}
