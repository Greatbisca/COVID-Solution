package com.codavel.howto_okhttp;

import android.app.AlertDialog;
import android.content.DialogInterface;
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

public class ProfissionalAdapter extends RecyclerView.Adapter<ProfissionalAdapter.MyViewHolder> {

    //List
    private ArrayList<String> professionalList;
    private ArrayList<Integer> professionalIds;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        TextView nome;
        ImageButton btnDelete;
        ImageButton btnEdit;

        public MyViewHolder(View view) {
            super(view);
            //initialize textviews
            nome = (TextView) view.findViewById(R.id.nome);
            btnEdit = (ImageButton) view.findViewById(R.id.btnEdit);
            btnDelete = (ImageButton) view.findViewById(R.id.btnDelete);
            btnDelete.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());

                    builder.setTitle("Eliminar Profissional");
                    builder.setMessage("Tem a certeza que pretende eliminar o profissional?");
                    builder.setIcon(R.drawable.ic_baseline_delete_24);
                    builder.setPositiveButton("Sim, eliminar", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            deleteProfessionalClick(getAdapterPosition());
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
    public  ProfissionalAdapter(ArrayList<String> nameList, ArrayList<Integer> idList) {
        this.professionalIds = idList;
        this.professionalList = nameList;
    }

    @Override
    public  ProfissionalAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        //layout inflator-set view of each item of recyclerview
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.lista_profissional_item, parent, false);
        return new  ProfissionalAdapter.MyViewHolder(itemView);
    }


    @Override
    public void onBindViewHolder( ProfissionalAdapter.MyViewHolder holder, int position) {
        //get item at position
        //setText from item to textview
        holder.nome.setText(professionalList.get(position));
    }

    @Override
    public int getItemCount() {

        return professionalList.size();
    }

    public void deleteProfessionalClick(Integer position) {
        Integer professionalid = professionalIds.get(position);

        OkHttpClient client = new OkHttpClient();

        // DELETE
        Request delete = new Request.Builder()
                .url("http://192.168.1.9:1919/api/profissional_saude/" + professionalid.toString())
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
        }
    }
}
