package com.api.carpintech.controllers;

import com.api.carpintech.models.Agenda;
import com.api.carpintech.repositories.AgendaRepository;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/agenda")
public class AgendaController
{

    private final AgendaRepository agendaRepository;

    public AgendaController(AgendaRepository agendaRepository) {
        this.agendaRepository = agendaRepository;
    }


    @GetMapping()
    public ResponseEntity<List> FindAll()
    {
        List<Agenda> agendas = agendaRepository.findAll();
        return new ResponseEntity<>(agendas, HttpStatusCode.valueOf(200));
    }









}
