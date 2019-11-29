package com.example.sigloxxi.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.sigloxxi.R;
import com.example.sigloxxi.model.Carrito;
import com.example.sigloxxi.model.OrdenH;

import java.util.List;

public class BoletaAdapter extends BaseAdapter
{
    private Context context;
    private int layout;
    private OrdenH boleta;

    public BoletaAdapter(Context context, int layout, OrdenH boleta) {
        this.context = context;
        this.layout = layout;
        this.boleta = boleta;
    }

    @Override
    public int getCount() {
        return 0;
    }

    @Override
    public Object getItem(int position) { return boleta.getOrdenBId().size(); }

    @Override
    public long getItemId(int position) { return 0; }

    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        ViewHolder holder ;

        if (convertView == null)
        {
            //inflamos la vista que nos llega con nuestro loyout
            LayoutInflater layoutInflater = LayoutInflater.from(this.context);
            convertView = layoutInflater.inflate(R.layout.boleta,null);
            holder = new ViewHolder();

            holder.boletaName = (TextView) convertView.findViewById(R.id.BoletaName);
            holder.boletaPrice= (TextView) convertView.findViewById(R.id.BoletaPrecio);
            convertView.setTag(holder);
        }
        else{
            holder = (ViewHolder) convertView.getTag();
        }

        String encabesado = boleta.getOrdenBId().get(position).getPlatilloId().getNombre()+" X "+ boleta.getOrdenBId().get(position).getCantidad();
        String total = Integer.toString(boleta.getOrdenBId().get(position).getSubtotal());
        holder.boletaName.setText(encabesado);
        holder.boletaPrice.setText(total);

        return convertView;
    }

    static class ViewHolder
    {
        private TextView boletaName;
        private TextView boletaPrice;
    }

}

