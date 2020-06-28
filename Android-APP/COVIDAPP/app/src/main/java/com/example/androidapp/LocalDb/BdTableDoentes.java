package com.example.androidapp.LocalDb;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.provider.BaseColumns;
import android.text.TextUtils;

import java.util.Arrays;

public class BdTableDoentes implements BaseColumns {

    public static final String NOME_TABELA = "doente";

    public static final String CAMPO_NOME = "nome";
    public static final String CAMPO_ID_UTILIZADOR = "id_utilizador";
    public static final String CAMPO_UTILIZADOR = "utilizador";

    public static final String CAMPO_ID_COMPLETO = NOME_TABELA + "." + _ID;
    public static final String CAMPO_NOME_COMPLETO = NOME_TABELA + "." + CAMPO_NOME;
    public static final String CAMPO_ID_UTILIZADOR_COMPLETO = NOME_TABELA + "." + CAMPO_ID_UTILIZADOR;
    public static final String CAMPO_UTILIZADOR_COMPLETO = BdTableUtilizadores.CAMPO_NOME_UTILIZADOR + " AS " + CAMPO_UTILIZADOR;

    public static final String[] TODOS_CAMPOS = {CAMPO_ID_COMPLETO, CAMPO_NOME_COMPLETO, CAMPO_ID_UTILIZADOR_COMPLETO, CAMPO_UTILIZADOR_COMPLETO};

    private SQLiteDatabase db;

    public BdTableDoentes(SQLiteDatabase db) {
        this.db = db;
    }

    public void cria() {
        db.execSQL("CREATE TABLE " + NOME_TABELA + "(" +
                _ID + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                CAMPO_NOME + " TEXT NOT NULL," +
                CAMPO_ID_UTILIZADOR + " INTEGER NOT NULL," +
                "FOREIGN KEY (" + CAMPO_ID_UTILIZADOR+ ") REFERENCES " +
                BdTableUtilizadores.NOME_TABELA + "("+ BdTableUtilizadores._ID + ")" +
                ")");
    }

    public long insert(ContentValues values) {
        return db.insert(NOME_TABELA, null, values);
    }

    public Cursor query(String[] columns, String selection,
                        String[] selectionArgs, String groupBy, String having,
                        String orderBy) {
        if (!Arrays.asList(columns).contains(CAMPO_UTILIZADOR_COMPLETO)) {
            return db.query(NOME_TABELA, columns, selection, selectionArgs, groupBy, having, orderBy);
        }

        String campos = TextUtils.join(",", columns);

        String sql = "SELECT " + campos;
        sql += " FROM " + NOME_TABELA + " INNER JOIN " + BdTableUtilizadores.NOME_TABELA;
        sql += " ON " + CAMPO_ID_UTILIZADOR_COMPLETO + "=" + BdTableUtilizadores.CAMPO_ID_COMPLETO;

        if (selection != null) {
            sql += " WHERE " + selection;
        }

        if (groupBy != null) {
            sql += " GROUP BY " + groupBy;

            if (having != null) {
                sql += " HAVING " + having;
            }
        }

        if (orderBy != null) {
            sql += " ORDER BY " + orderBy;
        }

        return db.rawQuery(sql, selectionArgs);
    }

    public int update(ContentValues values, String whereClause, String[] whereArgs) {
        return db.update(NOME_TABELA, values, whereClause, whereArgs);
    }

    public int delete(String whereClause, String[] whereArgs) {
        return db.delete(NOME_TABELA, whereClause, whereArgs);
    }
}
