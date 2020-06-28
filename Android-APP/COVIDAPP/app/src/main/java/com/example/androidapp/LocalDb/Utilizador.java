package com.example.androidapp.LocalDb;

public class Utilizador {
    private long id = -1;
    private String nome;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String descricao) {
        this.nome= descricao;
    }
}
