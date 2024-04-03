/**
 * Class Cliente.
 * 
 * Class that represents a Client of a company.
 * 
 * It has fields such as: id, name, cpf and phone number.
 * 
 * The id field is a UUID that is generated by the database.
 * 
 * The name field is a string that represents the name of the client.
 * 
 * The cpf field is a string that represents the CPF of the client.
 * 
 * The phoneNumber field is a string that represents the phone number of the client.
 * 
 * The class is annotated with @Entity and @Table(name = "cliente"),
 * to be used by JPA.
 * 
 * 
 */
package com.api.carpintech.models;

import jakarta.persistence.*;
import org.hibernate.annotations.GenericGenerator;
import java.util.UUID;

@Entity
@Table(name = "cliente")
public class Cliente {

    @Id
    @GeneratedValue(generator = "uuid2")
    @GenericGenerator(name = "uuid2", strategy = "uuid2")
    @Column(name = "id", nullable = false, columnDefinition = "BINARY(16)")
    private UUID id;
    
    @Column(name = "nome", nullable = false, length = 100)
    private String nome;
    
    @Column(name = "telefone", nullable = false, length = 100)
    private String telefone;
    
    @Column(name = "endereco", nullable = false, length = 100)
    private String endereco;
    
    public Cliente(String nome, String telefone, String endereco) {
        this.nome = nome;
        this.telefone = telefone;
        this.endereco = endereco;
    }

    public Cliente() {}

    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }
    public String getTelefone() {
        return telefone;
    }
    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }
    public String getEndereco() {
        return endereco;
    }
    public void setEndereco(String endereco) {
        this.endereco = endereco;
    }
    public UUID getId() {
        return id;
    }
    public void setId(UUID id) {
        this.id = id;
    }
}
