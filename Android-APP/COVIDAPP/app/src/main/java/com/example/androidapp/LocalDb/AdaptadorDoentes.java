package com.example.androidapp.LocalDb;

import android.content.Context;
import android.database.Cursor;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.androidapp.R;

public class AdaptadorDoentes extends RecyclerView.Adapter<AdaptadorDoentes.ViewHolderDoente>{
    private final Context context;
    private Cursor cursor = null;

    public void setCursor(Cursor cursor){
        if (cursor != this.cursor) {
            this.cursor = cursor;
            notifyDataSetChange();
        }
    }



    public AdaptadorDoentes(Context context) {
        this.context = context;
    }


    @NonNull
    @Override
    public AdaptadorDoentes.ViewHolderDoente onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemDoente = LayoutInflater.from(context).inflate(R.layout.activity_doente_list_item, parent, false);

        return new ViewHolderDoente(itemDoente);
    }

    @Override
    public void onBindViewHolder(@NonNull AdaptadorDoentes.ViewHolderDoente holder, int position) {
        cursor.moveToPosition(position);
        Doente doente = Converte.cursorToDoente(cursor);
        holder.setDoente(doente);
    }

    @Override
    public int getItemCount() {
        if(cursor == null) {
            return 0;
        }

        return cursor.getCount();
    }

    private ViewHolderDoente viewHolderDoenteSelecionado = null;

    public class ViewHolderDoente extends RecyclerView.ViewHolder  implements View.OnClickListener{
        private Doente doente = null;

        private final TextView textViewUtilizador;
        private final TextView textViewDoente;

        public ViewHolderDoente(@NonNull View itemView) {
            super(itemView);

            textViewDoente = (TextView)itemView.findViewById(R.id.textViewNome);
            textViewUtilizador = (TextView)itemView.findViewById(R.id.textViewUtilizador);

            itemView.setOnClickListener(this);
        }


        public void setDoente(Doente doente) {
            this.doente = doente;

            textViewDoente.setText(doente.getNome());
            textViewUtilizador.setText(String.valueOf(doente.getUtilizador()));
        }


        @Override
        public void onClick(View v) {
            this.doente = doente;

            textViewDoente.setText(doente.getNome());
            textViewUtilizador.setText(String.valueOf(doente.getUtilizador()));

            if (viewHolderDoenteSelecionado == this) {
                return;
            }

            if (viewHolderDoenteSelecionado != null) {
                viewHolderDoenteSelecionado.desSeleciona();
            }

            viewHolderDoenteSelecionado = this;
            seleciona();

            MainActivity activity = (MainActivity) AdaptadorDoentes.this.context;
            activity.doenteAlterado(doente);
        }

        private void seleciona() {
            itemView.setBackgroundResource(R.color.colorAccent);
        }

        private void desSeleciona() {
            itemView.setBackgroundResource(android.R.color.white);
        }
    }
}
