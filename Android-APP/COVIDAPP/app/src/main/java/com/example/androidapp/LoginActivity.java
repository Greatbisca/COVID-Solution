package com.example.androidapp;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;

import com.androidnetworking.AndroidNetworking;


public class LoginActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        AndroidNetworking.initialize(getApplicationContext());
        setContentView(R.layout.activity_login);


        final EditText etUsername = (EditText) findViewById(R.id.etUsername);
        final EditText etPassword = (EditText) findViewById(R.id.etPassword);
        final Button blogin = (Button) findViewById(R.id.blogin);


        }

        public void Registo(View view) {
            Intent intentregister = new Intent(this, Register.class);
            startActivity(intentregister);
        }

        public void Menu(View view) {
            Intent intentmenu = new Intent(this, Menus.class);
            startActivity(intentmenu);
        }
    }

