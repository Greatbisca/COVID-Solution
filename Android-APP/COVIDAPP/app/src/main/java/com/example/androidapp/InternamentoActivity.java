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

import java.time.OffsetDateTime;

public class InternamentoActivity extends AppCompatActivity {
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        AndroidNetworking.initialize(getApplicationContext());
        setContentView(R.layout.activity_internamento);
    }

    protected JSONObject CreateInternamento(Integer id_doente, String id_hospital, OffsetDateTime data_alta, OffsetDateTime data_internamento) throws JSONException {
        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();


        request.put("Patient", id_doente);
        request.put("Hospital", id_hospital);
        request.put("Date of internment", data_internamento);
        request.put("Discharge date", data_alta);

        try {
            AndroidNetworking.post("https://localhost:44328/api/internamento")
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

    protected JSONArray InternamentoList() {

        final JSONArray[] result = new JSONArray[1];
        try {
            AndroidNetworking.get("https://localhost:44328/api/internamento")
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

    protected void DeleteInternamento(Integer id_hospital){

        AndroidNetworking.delete("https://localhost:44328/api/internamento/" + id_hospital + "/")
                .setTag("test")
                .setPriority(Priority.LOW)
                .build();
    }

    protected JSONObject UpdateInternamento(Integer id_internamento, Integer id_doente, String id_hospital, OffsetDateTime data_alta, OffsetDateTime data_internamento) throws JSONException {
        final JSONObject[] result = {new JSONObject()};
        JSONObject request = new JSONObject();

        request.put("Internment", id_internamento);
        request.put("Patient", id_doente);
        request.put("Hospital", id_hospital);
        request.put("Date of internment", data_internamento);
        request.put("Discharge date", data_alta);

        try {
            AndroidNetworking.post("https://localhost:44328/api/internamento")
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
        } finally {
            return result[0];
        }
    }

        protected JSONArray InternamentoDetail(Integer id_internamento) {

            final JSONArray[] result = new JSONArray[1];
            try {
                AndroidNetworking.get("https://localhost:44328/api/internamento/" + id_internamento + "/")
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
