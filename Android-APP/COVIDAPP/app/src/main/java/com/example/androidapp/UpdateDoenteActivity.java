package com.example.androidapp;

import android.os.Bundle;

public class UpdateDoenteActivity extends DoenteActivity {

    private Object currentdoente;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_doente);
    }

    public void GetDoente(int id){
        currentdoente = super.DoenteDetail(id);
    }
}
