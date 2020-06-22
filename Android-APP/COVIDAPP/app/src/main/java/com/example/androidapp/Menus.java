package com.example.androidapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class Menus extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menus);
        Intent intentmenu = getIntent();
    }

    public void Doente(View view) {
        Intent intentdoente = new Intent(this, DoenteActivity.class);
        startActivity(intentdoente);
    }
}
