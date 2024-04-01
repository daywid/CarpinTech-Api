/**
* Class Agenda.
* 
* Class that represents a work schedule of a company.
* 
* It has fields such as: id, description, date, type and employee.
* 
* The type field is a string that can be "work" or "holiday".
* 
* The employee field is an object of type Employee.
* 
* The class is annotated with @Entity and @Table(name = "agenda"),
* to be used by JPA.
* 
* 
*/
package com.api.carpintech.models;

import org.hibernate.annotations.GenericGenerator;
import org.springframework.data.annotation.Id;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import java.util.*;

@Entity
@Table(name = "agenda")
public class Agenda {
    
    @Id
    @GeneratedValue(generator = "uuid2")
    @GenericGenerator(name = "uuid2", strategy = "uuid2")
    @Column(name = "id", nullable = false, columnDefinition = "BINARY(16)")
    private UUID id;
    private String descricao;
    /**
     * Test with Calendar from java util, 
     * Joda Time is an option too.
    */
    private Calendar data;
    private String tipo;

    @ManyToOne
    private Funcionario funcionario;

    public UUID getId() {
        return id;
    }
    public void setId(UUID id) {
        this.id = id;
    }
    public String getDescricao() {
        return descricao;
    }
    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }
  
    public String getTipo() {
        return tipo;
    }
    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
    public Calendar getData() {
        return data;
    }
    public void setData(Calendar data) {
        this.data = data;
    }
    public Funcionario getFuncionario() {
        return funcionario;
    }
    public void setFuncionario(Funcionario funcionario) {
        this.funcionario = funcionario;
    }
    
    

}
