package com.codavel.howto_okhttp;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.ResponseBody;

public class ListDoenteActivity extends AppCompatActivity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_doente);

        OkHttpClient client = new OkHttpClient();

        // GET
        Request get = new Request.Builder()
                .url("http://192.168.1.8:24897/api/doente")
                .build();

        client.newCall(get).enqueue(new Callback() {
            @Override
            public void onFailure(Call call, IOException e) {
                e.printStackTrace();
            }

            @Override
            public void onResponse(Call call, Response response) {
                try {
                    final ArrayList<String> Nomes = new ArrayList<>();
                    ResponseBody responseBody = response.body();
                    if (!response.isSuccessful()) {
                        throw new IOException("Unexpected code " + response);
                    }
                    JSONArray doentesArray = new JSONArray(responseBody.string());
                    // implement for loop for getting users list data
                    for (int i = 0; i < doentesArray.length(); i++) {
                        // create a JSONObject for fetching single user data
                        JSONObject doentesDetail = doentesArray.getJSONObject(i);
                        // fetch email and name and store it in arraylist
                        Nomes.add(doentesDetail.getString("nome"));
                    }
                    ListDoenteActivity.this.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            // get the reference of RecyclerView
                            RecyclerView recyclerView = (RecyclerView) findViewById(R.id.recyclerView);
                            // set a LinearLayoutManager with default vertical orientation
                            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getApplicationContext());
                            recyclerView.setLayoutManager(linearLayoutManager);

                            //  call the constructor of CustomAdapter to send the reference and data to Adapter
                            CustomAdapter customAdapter = new CustomAdapter(Nomes);
                            recyclerView.setAdapter(customAdapter); // set the Adapter to RecyclerView
                        }
                    });

                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });
    }
}
