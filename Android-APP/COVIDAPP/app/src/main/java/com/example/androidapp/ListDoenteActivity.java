package com.example.androidapp;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.google.gson.JsonObject;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.json.JSONStringer;

import java.lang.reflect.Array;
import java.util.ArrayList;

public class ListDoenteActivity extends AppCompatActivity {

    ListView simpleList;
    ArrayList <String> lista = new ArrayList<>();


        ArrayList<String> Nomes = new ArrayList<>();

        protected void onCreate(Bundle savedInstanceState) {
            super.onCreate(savedInstanceState);
            setContentView(R.layout.activity_list_doente);
            Intent intentdoente = getIntent();
            // get the reference of RecyclerView
            RecyclerView recyclerView = (RecyclerView) findViewById(R.id.recyclerView);
            // set a LinearLayoutManager with default vertical orientation
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getApplicationContext());
            recyclerView.setLayoutManager(linearLayoutManager);

            try {
                // get JSONObject from JSON file
                JSONObject obj = new JSONObject ("{ \"doentes\": [ { \"nome\": \"diogo biscaia\", \"id\": 1 } ] }");

                // fetch JSONArray named users
                JSONArray doentesArray = obj.getJSONArray("doentes");
                // implement for loop for getting users list data
                for (int i = 0; i < doentesArray.length(); i++) {
                    // create a JSONObject for fetching single user data
                    JSONObject doentesDetail = doentesArray.getJSONObject(i);
                    // fetch email and name and store it in arraylist
                    Nomes.add(doentesDetail.getString("nome"));
                }
            } catch (JSONException e) {
                e.printStackTrace();
            }

            //  call the constructor of CustomAdapter to send the reference and data to Adapter
            CustomAdapter customAdapter = new CustomAdapter(Nomes);
            recyclerView.setAdapter(customAdapter); // set the Adapter to RecyclerView
        }





       /*
       DoenteActivity apicall = new DoenteActivity();
       JSONArray apilista = apicall.DoenteList();

        for(int i=0; i<apilista.length(); i++){
            JSONObject registo = null;
            try {
                registo = apilista.getJSONObject(i);
                lista.add(registo.get("nome").toString());
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }

        setContentView(R.layout.activity_list_doente);
        simpleList = (ListView)findViewById(R.id.simpleListView);
        ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(this, R.layout.activity_doente_list_item, R.id.textView, lista);
        simpleList.setAdapter(arrayAdapter);
        //lista = (ListView) findViewById(R.id.list);

            simpleList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                }
            });*/
        }

