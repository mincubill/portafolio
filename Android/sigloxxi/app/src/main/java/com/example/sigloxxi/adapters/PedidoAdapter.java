package com.example.sigloxxi.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.sigloxxi.R;
import com.example.sigloxxi.model.Carrito;


import java.util.List;

public class PedidoAdapter extends BaseAdapter
{
    private Context context;
    private int layout;
    private List<Carrito> pedidos;

    public PedidoAdapter(Context context, int layout, List<Carrito> pedidos) {
        this.context = context;
        this.layout = layout;
        this.pedidos = pedidos;
    }

    @Override
    public int getCount() {
        return pedidos.size();
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder ;

        if (convertView == null)
        {
            //inflamos la vista que nos llega con nuestro loyout
            LayoutInflater layoutInflater = LayoutInflater.from(this.context);
            convertView = layoutInflater.inflate(R.layout.pedido,null);
            holder = new ViewHolder();

            //referenciamos el elemento a modificar y lo rellenamos
            holder.pedidoName = (TextView) convertView.findViewById(R.id.pedidoName);
            holder.pedidoCantidad = (TextView) convertView.findViewById(R.id.pedidoCantidad);
            convertView.setTag(holder);
        }
        else {
            holder = (ViewHolder) convertView.getTag();
        }

        String nombre = pedidos.get(position).getNombre();
        String cantidad = Integer.toString(pedidos.get(position).getCantidad());
        holder.pedidoName.setText(nombre);
        holder.pedidoCantidad.setText(cantidad);


        return convertView;
    }

    static class ViewHolder
    {
        private TextView pedidoName;
        private TextView pedidoCantidad;
    }
}

