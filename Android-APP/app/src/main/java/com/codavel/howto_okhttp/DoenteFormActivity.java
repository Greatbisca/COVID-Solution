package com.codavel.howto_okhttp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.TextView;

import com.google.gson.JsonObject;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;
import okhttp3.ResponseBody;

public class DoenteFormActivity  extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_doente);
        Intent intent = getIntent();

        if (intent.getStringExtra("Doente id") != null) {
            OkHttpClient client = new OkHttpClient();

            // GET
            Request get = new Request.Builder()
                    .url("http://192.168.1.8:24897/api/doente/" + intent.getStringExtra("Doente id"))
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
                        ResponseBody responseBody = response.body();
                        if (!response.isSuccessful()) {
                            throw new IOException("Unexpected code " + response);
                        }
                        JSONObject doente = new JSONObject(responseBody.string());
                        TextView txtnome = findViewById(R.id.txtDoenteNome);
                        TextView txtlocalizacao = findViewById(R.id.txtDoenteLocalizacao);
                        TextView txtid = findViewById(R.id.txtDoenteId);

                        txtnome.setText(doente.getString("nome"));
                        txtlocalizacao.setText(doente.getString("localizacao"));
                        txtid.setText(doente.getInt("id"));
                    } catch (JSONException e) {
                        e.printStackTrace();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            });
        } else {
            TextView txtnome = findViewById(R.id.txtDoenteNome);
            TextView txtlocalizacao = findViewById(R.id.txtDoenteLocalizacao);
            TextView txtid = findViewById(R.id.txtDoenteId);

            txtnome.setText("");
            txtlocalizacao.setText("");
            txtid.setText("0");
        }
    }

    private void SaveDoente(){
        TextView txtid = findViewById(R.id.txtDoenteId);
        TextView txtnome = findViewById(R.id.txtDoenteNome);
        TextView txtlocalizacao = findViewById(R.id.txtDoenteLocalizacao);
        if(txtid.getText().toString() == "0"){
            OkHttpClient client = new OkHttpClient();



            JsonObject postData = new JsonObject();
            postData.addProperty("nome", txtnome.getText().toString());
            postData.addProperty("localizacao", txtlocalizacao.getText().toString());



            final MediaType JSON = MediaType.parse("application/json; charset=utf-8");
            RequestBody postBody = RequestBody.create(JSON, postData.toString());
            Request post = new Request.Builder()
                    .url("http://192.168.1.8:24897/api/doente")
                    .post(postBody)
                    .addHeader("Cache-Control", "no-cache")
                    .build();

            client.newCall(post).enqueue(new Callback() {

                @Override
                public void onFailure(Call call, IOException e) {
                    e.printStackTrace();
                }



                @Override
                public void onResponse(Call call, Response response) {
                    try {
                        ResponseBody responseBody = response.body();
                        if (!response.isSuccessful()) {
                            throw new IOException("Unexpected code " + response);
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            });
        }else{
            OkHttpClient client = new OkHttpClient();



            JsonObject putData = new JsonObject();
            putData.addProperty("nome", txtnome.getText().toString());
            putData.addProperty("localizacao", txtlocalizacao.getText().toString());



            final MediaType JSON = MediaType.parse("application/json; charset=utf-8");
            RequestBody putBody = RequestBody.create(JSON, putData.toString());
            Request put = new Request.Builder()
                    .url("http://192.168.1.8:24897/api/doente/" + txtid.getText().toString())
                    .put(putBody)
                    .addHeader("Cache-Control", "no-cache")
                    .build();

            client.newCall(put).enqueue(new Callback() {

                @Override
                public void onFailure(Call call, IOException e) {
                    e.printStackTrace();
                }



                @Override
                public void onResponse(Call call, Response response) {
                    try {
                        ResponseBody responseBody = response.body();
                        if (!response.isSuccessful()) {
                            throw new IOException("Unexpected code " + response);
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }

        });
        }
    }
}