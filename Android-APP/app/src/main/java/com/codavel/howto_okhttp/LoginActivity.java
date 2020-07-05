package com.codavel.howto_okhttp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.EditText;






public class LoginActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);


        final EditText etUsername = (EditText) findViewById(R.id.username);
        final EditText etPassword = (EditText) findViewById(R.id.password);

    }

    public void Menu(View view) {
        Intent intentmenu = new Intent(this, Menus.class);
        startActivity(intentmenu);
    }

    public void Registo(View view) {
        Intent intentregister = new Intent(this, Register.class);
        startActivity(intentregister);
    }


}
