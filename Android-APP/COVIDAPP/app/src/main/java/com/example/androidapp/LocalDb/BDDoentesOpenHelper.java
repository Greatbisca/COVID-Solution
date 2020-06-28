package com.example.androidapp.LocalDb;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class BDDoentesOpenHelper extends SQLiteOpenHelper {
    public static final String NOME_BASE_DADOS = "doentes.db";
    private static final int VERSAO_BASE_DADOS = 1;
    private static final boolean DESENVOLVIMENTO = true;

    public BDDoentesOpenHelper(@Nullable Context context, @Nullable String name, @Nullable SQLiteDatabase.CursorFactory factory, int version) {
        super(context, NOME_BASE_DADOS, null, VERSAO_BASE_DADOS);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        BdTableUtilizadores tabelaUtilizadores = new BdTableUtilizadores(db);
        tabelaUtilizadores.cria();

        BdTableDoentes tabelaDoentes = new BdTableDoentes(db);
        tabelaDoentes.cria();

        if (DESENVOLVIMENTO) {
            seedData(db);
        }
    }

    private void seedData(SQLiteDatabase db) {
        BdTableUtilizadores tabelaUtilizadores = new BdTableUtilizadores(db);

        Utilizador utilizador = new Utilizador();
        utilizador.setNome("Diogo");
        long idUtiDiogo = tabelaUtilizadores.insert(Converte.categoriaToContentValues(utilizador));

        utilizador = new Utilizador();
        utilizador.setNome("Antonio");
        long idUtiAntonio = tabelaUtilizadores.insert(Converte.categoriaToContentValues(utilizador));

        utilizador = new Utilizador();
        utilizador.setNome("Miguel");
        long idUtiMiguel = tabelaUtilizadores.insert(Converte.categoriaToContentValues(utilizador));

        utilizador = new Utilizador();
        utilizador.setNome("Afonso");
        tabelaUtilizadores.insert(Converte.categoriaToContentValues(utilizador));

        BdTableDoentes tabelaDoentes = new BdTableDoentes(db);

        Doente doente = new Doente();
        doente.setNome("Biscaia");
        doente.setIdUtilizador(idUtiDiogo);
        tabelaDoentes.insert(Converte.livroToContentValues(doente));

        doente = new Doente();
        doente.setNome("Caetano");
        doente.setIdUtilizador(idUtiAntonio);
        tabelaDoentes.insert(Converte.livroToContentValues(doente));

        doente = new Doente();
        doente.setNome("Antunes");
        doente.setIdUtilizador(idUtiMiguel);
        tabelaDoentes.insert(Converte.livroToContentValues(doente));

    }


    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

    }
}
