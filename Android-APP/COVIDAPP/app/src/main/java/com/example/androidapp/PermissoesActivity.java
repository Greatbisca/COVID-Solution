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

public class PermissoesActivity extends AppCompatActivity {
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        AndroidNetworking.initialize(getApplicationContext());
        setContentView(R.layout.activity_login);
    }

    protected JSONObject CreatePermissoes(Integer id_perfil_utilizador, Integer id_modulo, Boolean ler, Boolean escrever, Boolean criar, Boolean eliminar) throws JSONException {
        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();

        request.put("Id User profile", id_perfil_utilizador);
        request.put("Id module", id_modulo);
        request.put("Read", ler);
        request.put("Write", escrever);
        request.put("Create", criar);
        request.put("Delete", eliminar);

        try {
            AndroidNetworking.post("https://localhost:44328/api/permissoes")
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

    protected JSONArray PermissoesList() {

        final JSONArray[] result = new JSONArray[1];
        try {
            AndroidNetworking.get("https://localhost:44328/api/permissoes")
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

    protected void DeletePermissoes(Integer id_permissoes){

        AndroidNetworking.delete("https://localhost:44328/api/permissoes/" + id_permissoes + "/")
                .setTag("test")
                .setPriority(Priority.LOW)
                .build();
    }

    protected JSONObject UpdatePermissoes(Integer id_permissoes, Integer id_perfil_utilizador, Integer id_modulo, Boolean ler, Boolean escrever, Boolean criar, Boolean eliminar) throws JSONException {
        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();

        request.put("Id", id_permissoes);
        request.put("Id User profile", id_perfil_utilizador);
        request.put("Id module", id_modulo);
        request.put("Read", ler);
        request.put("Write", escrever);
        request.put("Create", criar);
        request.put("Delete", eliminar);

        try {
            AndroidNetworking.post("https://localhost:44328/api/permissoes")
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

    protected JSONArray PermissoesDetail(Integer id_permissoes) {

        final JSONArray[] result = new JSONArray[1];
        try {
            AndroidNetworking.get("https://localhost:44328/api/permissoes/" + id_permissoes + "/")
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
