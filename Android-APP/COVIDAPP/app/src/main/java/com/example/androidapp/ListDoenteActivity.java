package com.example.androidapp;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

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

import java.lang.reflect.Array;
import java.util.ArrayList;

public class ListDoenteActivity extends AppCompatActivity {

    ListView simpleList;
    ArrayList <String> lista = new ArrayList<>();


        @RequiresApi(api = Build.VERSION_CODES.KITKAT)
        @Override

        protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        DoenteActivity apicall = new DoenteActivity();
       /* JSONArray apilista = apicall.DoenteList();

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
}
