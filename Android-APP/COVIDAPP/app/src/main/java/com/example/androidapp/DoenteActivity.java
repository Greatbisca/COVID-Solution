package com.example.androidapp;

import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.view.View;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import com.androidnetworking.AndroidNetworking;
import com.androidnetworking.common.Priority;
import com.androidnetworking.error.ANError;
import com.androidnetworking.interfaces.JSONArrayRequestListener;
import com.androidnetworking.interfaces.JSONObjectRequestListener;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class DoenteActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        AndroidNetworking.initialize(getApplicationContext());
        setContentView(R.layout.activity_doente);
        Intent intentdoente = getIntent();
    }

    public void ListaDoente(View view) {
        Intent intentdoentelista = new Intent(this, DoenteListaItemActivity.class);
        startActivity(intentdoentelista);
    }


    protected JSONObject CreateDoente(String nome, Integer idade, String sexo, String morada, Integer cc, Integer nib, String regiao) throws JSONException {
        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();
        request.put("Name", nome);
        request.put("Age", idade);
        request.put("Sex", sexo);
        request.put("Address", morada);
        request.put("CC", cc);
        request.put("NIB", nib);
        request.put("Region", regiao);

        try {
            AndroidNetworking.post("https://localhost:44328/api/doente")
                    .addBodyParameter(request)
                    .setPriority(Priority.MEDIUM)
                    .build()
                    .getAsJSONObject(new JSONObjectRequestListener() {
                        @Override
                        public void onResponse(JSONObject response) {
                            result[0] = response;
                        }

                        @Override
                        public void onError(ANError error) {
                            try {
                                throw new Exception(error);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    });
        }catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            return result[0];
        }
    }

    protected JSONArray DoenteList() {

        final JSONArray[] result = new JSONArray[1];
        try {
            AndroidNetworking.get("https://192.168.56.1:44328/api/doente/")
                    .setTag("test")
                    .setPriority(Priority.LOW)
                    .build()
                    .getAsJSONArray(new JSONArrayRequestListener() {
                        @Override
                        public void onResponse(JSONArray response) {
                            result[0] = response;
                        }

                        @Override
                        public void onError(ANError error) {
                            try {
                                throw new Exception(error);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    });
        } catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            return result[0];
        }
    }



    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    protected String GenericGet(String url) throws IOException{
        OkHttpClient client = new OkHttpClient();


            Request request = new Request.Builder()
                    .url(url)
                    .build();

            try (Response response = client.newCall(request).execute()) {
                return response.body().string();
            }
        }



    protected void DeleteDoeente(Integer id_doente){

        AndroidNetworking.delete("https://192.168.56.1:44328/api/doente/" + id_doente + "/")
                .setTag("test")
                .setPriority(Priority.LOW)
                .build();
    }

    protected JSONObject UpdateDoente(Integer id_doente, String nome, Integer idade, String sexo, String morada, Integer cc, Integer nib, String regiao) throws JSONException {

        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();
        request.put("Id", id_doente);
        request.put("Name", nome);
        request.put("Age", idade);
        request.put("Sex", sexo);
        request.put("Address", morada);
        request.put("CC", cc);
        request.put("NIB", nib);
        request.put("Region", regiao);

        try{
        AndroidNetworking.put("https://192.168.56.1:44328/api/doente/" + id_doente + "/")
                .addBodyParameter(request)
                .setPriority(Priority.MEDIUM)
                .build()
                .getAsJSONObject(new JSONObjectRequestListener() {
                    @Override
                    public void onResponse(JSONObject response) {
                        result[0] = response;
                    }

                    @Override
                    public void onError(ANError error) {
                        try {
                            throw new Exception(error);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });
        } catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            return result[0];
        }
    }

    protected JSONArray DoenteDetail(Integer id) {

        final JSONArray[] result = new JSONArray[1];
        try {
            AndroidNetworking.get("https://192.168.56.1:44328/api/doente/" + id + "/")
                    .setTag("test")
                    .setPriority(Priority.LOW)
                    .build()
                    .getAsJSONArray(new JSONArrayRequestListener() {
                        @Override
                        public void onResponse(JSONArray response) {
                            result[0] = response;
                        }

                        @Override
                        public void onError(ANError error) {
                            try {
                                throw new Exception(error);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    });
        } catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            return result[0];
        }
    }

}
