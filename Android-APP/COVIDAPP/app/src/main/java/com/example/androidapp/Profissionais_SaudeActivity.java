package com.example.androidapp;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;

import com.androidnetworking.AndroidNetworking;
import com.androidnetworking.common.Priority;
import com.androidnetworking.error.ANError;
import com.androidnetworking.interfaces.JSONArrayRequestListener;
import com.androidnetworking.interfaces.JSONObjectRequestListener;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class Profissionais_SaudeActivity extends AppCompatActivity {
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        AndroidNetworking.initialize(getApplicationContext());
        setContentView(R.layout.activity_profissionais_saude);
    }

    protected JSONObject CreateProfissionais_Saude(String nome, Integer idade, String sexo, String morada, Integer cc, Integer nib, String profissao, Integer id_hopistal) throws JSONException {
        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();
        request.put("Name", nome);
        request.put("Age", idade);
        request.put("Sex", sexo);
        request.put("Address", morada);
        request.put("CC", cc);
        request.put("NIB", nib);
        request.put("Profession", profissao);
        request.put("Hospital", id_hopistal);

        try {
            AndroidNetworking.post("https://localhost:44328/api/profissionais_saude")
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

    protected JSONArray Profissionais_SaudeList() {

        final JSONArray[] result = new JSONArray[1];
        try {
            AndroidNetworking.get("https://localhost:44328/api/profissionais_saude")
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

    protected void DeleteProfissionais_Saude(Integer id_profissionais_saude){

        AndroidNetworking.delete("https://localhost:44328/api/profissionais_saude/" + id_profissionais_saude + "/")
                .setTag("test")
                .setPriority(Priority.LOW)
                .build();
    }

    protected JSONObject UpdateProfissionais_Saude(Integer id_profissionais_saude, String nome, Integer idade, String sexo, String morada, Integer cc, Integer nib, String profissao, Integer id_hopistal) throws JSONException {

        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();
        request.put("Id", id_profissionais_saude);
        request.put("Name", nome);
        request.put("Age", idade);
        request.put("Sex", sexo);
        request.put("Address", morada);
        request.put("CC", cc);
        request.put("NIB", nib);
        request.put("Profession", profissao);
        request.put("Hospital", id_hopistal);

        try{
            AndroidNetworking.put("https://localhost:44328/api/profissionais_saude/" + id_profissionais_saude + "/")
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

    protected JSONArray Profissionais_SaudeDetail(Integer id_profissionais_saude) {

        final JSONArray[] result = new JSONArray[1];
        try {
            AndroidNetworking.get("https://localhost:44328/api/profissionais_saude/" + id_profissionais_saude + "/")
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
