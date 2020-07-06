package com.codavel.howto_okhttp;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
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

public class ListProfissionalActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_profissional);

        OkHttpClient client = new OkHttpClient();

        // GET
        Request get = new Request.Builder()
                .url("http://192.168.1.9:1919/api/profissional_saude")
                .addHeader("Cache-Control", "no-cache")
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
                    final ArrayList<Integer> Ids = new ArrayList<>();
                    ResponseBody responseBody = response.body();
                    if (!response.isSuccessful()) {
                        throw new IOException("Unexpected code " + response);
                    }
                    JSONArray professionalArray = new JSONArray(responseBody.string());
                    // implement for loop for getting users list data
                    for (int i = 0; i < professionalArray.length(); i++) {
                        // create a JSONObject for fetching single user data
                        JSONObject professionalDetail = professionalArray.getJSONObject(i);
                        // fetch email and name and store it in arraylist
                        Nomes.add(professionalDetail.getString("nome"));
                        Ids.add(professionalDetail.getInt("id"));
                    }
                    ListProfissionalActivity.this.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            // get the reference of RecyclerView
                            RecyclerView recyclerView = (RecyclerView) findViewById(R.id.recyclerView);
                            // set a LinearLayoutManager with default vertical orientation
                            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getApplicationContext());
                            recyclerView.setLayoutManager(linearLayoutManager);

                            //  call the constructor of CustomAdapter to send the reference and data to Adapter
                            ProfissionalAdapter customAdapter = new ProfissionalAdapter(Nomes, Ids);
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
