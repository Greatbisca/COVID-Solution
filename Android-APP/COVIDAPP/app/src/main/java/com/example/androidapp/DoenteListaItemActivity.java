package com.example.androidapp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;


public class DoenteListaItemActivity extends AppCompatActivity {

    ListView simpleList;
    ArrayList<String> lista = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_doente_lista_item);
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
        ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(this, R.layout.activity_doente_lista_item, R.id.Lista, lista);
        simpleList.setAdapter(arrayAdapter);
        //lista = (ListView) findViewById(R.id.Lista);

            simpleList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                }
            });
    }
}
