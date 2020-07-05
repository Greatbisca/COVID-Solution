package com.codavel.howto_okhttp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;

public class Menus extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menus);
        Intent intentmenu = getIntent();
    }

    public void Doente(View view) {
        Intent intentdoente = new Intent(this, ListDoenteActivity.class);
        startActivity(intentdoente);
    }

    public void Profissional(View view) {
        Intent intentprofissional = new Intent(this, ListProfissionalActivity.class);
        startActivity(intentprofissional);
    }
}