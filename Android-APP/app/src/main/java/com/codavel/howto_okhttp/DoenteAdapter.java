package com.codavel.howto_okhttp;


import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.TextView;

import java.io.IOException;
import java.util.ArrayList;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class DoenteAdapter extends RecyclerView.Adapter<DoenteAdapter.MyViewHolder> {

    //List
    private ArrayList<String> doenteList;
    private ArrayList<Integer> doenteIds;
    private Activity activity;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        TextView nome;
        ImageButton btnDelete;
        ImageButton btnEdit;

        public MyViewHolder(final View view) {
            super(view);
            //initialize textviews
            nome = (TextView) view.findViewById(R.id.nome);
            btnEdit = (ImageButton) view.findViewById(R.id.btnEdit);
            btnEdit.setOnClickListener(new View.OnClickListener() {
                                           @Override
                                           public void onClick(View v) {
                                               editDoenteClick(view.getContext(),getAdapterPosition());
                                           }
                                       });
                    btnDelete = (ImageButton) view.findViewById(R.id.btnDelete);
            btnDelete.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());

                    builder.setTitle("Eliminar Doente");
                    builder.setMessage("Tem a certeza que pretende eliminar o doente?");
                    builder.setIcon(R.drawable.ic_baseline_delete_24);
                    builder.setPositiveButton("Sim, eliminar", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            deleteDoenteClick(getAdapterPosition());
                        }
                    });

                    builder.setNegativeButton("Não, cancelar", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            // cancelar
                        }
                    });

                    builder.show();
                }
            });
        }
    }

    //constructor
    public DoenteAdapter(Activity activity, ArrayList<String> nameList, ArrayList<Integer> idList) {
        this.activity = activity;
        this.doenteIds = idList;
        this.doenteList = nameList;
    }

    @Override
    public MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        //layout inflator-set view of each item of recyclerview
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.lista_doente_item, parent, false);
        return new MyViewHolder(itemView);
    }


    @Override
    public void onBindViewHolder(MyViewHolder holder, int position) {
        //get item at position
        //setText from item to textview
        holder.nome.setText(doenteList.get(position));
    }

    @Override
    public int getItemCount() {

        return doenteList.size();
    }

    public void deleteDoenteClick(Integer position) {
        final Integer doenteid = doenteIds.get(position);
        Thread thread = new Thread(new Runnable() {

            @Override
            public void run() {

                OkHttpClient client = new OkHttpClient();

                // DELETE
                Request delete = new Request.Builder()
                        .url("http://192.168.1.9:1919/api/doente/" + doenteid.toString())
                        .delete()
                        .addHeader("Cache-Control", "no-cache")
                        .build();
                try {
                    Response response = client.newCall(delete).execute();
                    if (!response.isSuccessful()) {
                        throw new IOException("Unexpected code " + response);
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                } catch (Exception e) {
                    Integer i = 1;
                }
            }
            });
        }

    public void editDoenteClick(Context context, Integer position){
        Integer doenteid = doenteIds.get(position);

        Intent intent = new Intent(context, DoenteFormActivity.class);
        intent.putExtra("Doente id", doenteid);
        activity.startActivity(intent);
    }
}
