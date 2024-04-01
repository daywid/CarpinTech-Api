/**
 * Class Funcionario.
 * 
 * Class that represents an employee of a company.
 * 
 * It has fields such as: id, name, cpf, rg, phone number and address.
 * 
 * The id field is a UUID that is generated by the database.
 * 
 * The name field is a string that represents the name of the employee.
 * 
 * The cpf field is a string that represents the CPF of the employee.
 * 
 * The rg field is a string that represents the RG of the employee.
 * 
 * The phoneNumber field is a string that represents the phone number of the employee.
 * 
 * The address field is an object of type Address.
 * 
 * The class is annotated with @Entity and @Table(name = "funcionario"),
 * to be used by JPA.
 * 
 * 
 */

package com.api.carpintech.models;

import org.hibernate.annotations.GenericGenerator;
import org.springframework.data.annotation.Id;
import java.util.UUID;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Table;

@Entity
@Table(name = "funcionario")
public class Funcionario {

    @Id
    @GeneratedValue(generator = "uuid2")
    @GenericGenerator(name = "uuid2", strategy = "uuid2")
    @Column(name = "id", nullable = false, columnDefinition = "BINARY(16)")
    private UUID id;

    @Column(name = "nome", nullable = false, length = 100)
    private String nome;

    @Column(name = "funcao", nullable = false, length = 100)
    private String funcao;
    
    @Column(name = "salario", nullable = false)
    private Double salario;
    
    @Column(name = "horasTrabalhadas")
    private Double horasTrabalhadas;

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getFuncao() {
        return funcao;
    }

    public void setFuncao(String funcao) {
        this.funcao = funcao;
    }

    public Double getSalario() {
        return salario;
    }

    public void setSalario(Double salario) {
        this.salario = salario;
    }

    public Double getHorasTrabalhadas() {
        return horasTrabalhadas;
    }

    public void setHorasTrabalhadas(Double horasTrabalhadas) {
        this.horasTrabalhadas = horasTrabalhadas;
    }
   

}
