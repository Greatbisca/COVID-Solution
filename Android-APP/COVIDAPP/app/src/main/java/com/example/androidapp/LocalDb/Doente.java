package com.example.androidapp.LocalDb;

public class Doente {
    private long id = -1;
    private String nome;
    private long idUtilizador = -1;
    private String utilizador = null;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public long getIdUtilizador() {
        return idUtilizador;
    }

    public void setIdUtilizador(long idUtilizador) {
        this.idUtilizador = idUtilizador;
    }

    public String getUtilizador() {
        return utilizador;
    }

    public void setUtilizador(String utilizador) { this.utilizador = utilizador; }
}
