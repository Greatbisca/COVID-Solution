package com.example.androidapp.LocalDb;

import android.content.ContentValues;
import android.database.Cursor;

public class Converte {
    public static ContentValues categoriaToContentValues(Utilizador utilizador) {
        ContentValues valores = new ContentValues();

        valores.put(BdTableUtilizadores.CAMPO_NOME, utilizador.getNome());

        return valores;
    }

    public static Utilizador contentValuesToUtilizador(ContentValues valores) {
        Utilizador utilizador = new Utilizador();

        utilizador.setId(valores.getAsLong(BdTableUtilizadores._ID));
        utilizador.setNome(valores.getAsString(BdTableUtilizadores.CAMPO_NOME));

        return utilizador;
    }

    public static ContentValues livroToContentValues(Doente doente) {
        ContentValues valores = new ContentValues();

        valores.put(BdTableDoentes.CAMPO_NOME, doente.getNome());
        valores.put(BdTableDoentes.CAMPO_ID_UTILIZADOR, doente.getIdUtilizador());

        return valores;
    }

    public static Doente contentValuesToDoente(ContentValues valores) {
        Doente doente = new Doente();

        doente.setId(valores.getAsLong(BdTableDoentes._ID));
        doente.setNome(valores.getAsString(BdTableDoentes.CAMPO_NOME));
        doente.setIdUtilizador(valores.getAsLong(BdTableDoentes.CAMPO_ID_UTILIZADOR));
        doente.setUtilizador(valores.getAsString(BdTableDoentes.CAMPO_UTILIZADOR));

        return doente;
    }

    public static Doente cursorToDoente(Cursor cursor) {
        Doente doente = new Doente();

        doente.setId(cursor.getLong(cursor.getColumnIndex(BdTableDoentes._ID)));
        doente.setNome(cursor.getString(cursor.getColumnIndex(BdTableDoentes.CAMPO_NOME)));
        doente.setIdUtilizador(cursor.getLong(cursor.getColumnIndex(BdTableDoentes.CAMPO_ID_UTILIZADOR)));
        doente.setUtilizador(cursor.getString(cursor.getColumnIndex(BdTableDoentes.CAMPO_UTILIZADOR)));

        return doente;
    }
}
