package com.example.androidapp;


import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

public class CustomAdapter extends RecyclerView.Adapter<CustomAdapter.MyViewHolder> {

    //List
    private ArrayList<String> doenteList;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        TextView nome;

        public MyViewHolder(View view) {
            super(view);
            //initialize textviews
            nome = (TextView) view.findViewById(R.id.nome);
        }
    }

    //constructor
    public CustomAdapter(ArrayList<String> nameList) {
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
}


