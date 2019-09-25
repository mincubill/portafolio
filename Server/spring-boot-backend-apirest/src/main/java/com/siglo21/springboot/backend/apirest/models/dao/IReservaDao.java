package com.siglo21.springboot.backend.apirest.models.dao;

import org.springframework.data.repository.CrudRepository;

import com.siglo21.springboot.backend.apirest.models.entity.Reserva;

public interface IReservaDao extends CrudRepository<Reserva, Integer>{

}
