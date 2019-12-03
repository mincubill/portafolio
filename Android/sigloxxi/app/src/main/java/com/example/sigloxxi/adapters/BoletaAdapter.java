package com.example.sigloxxi.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.sigloxxi.R;
import com.example.sigloxxi.model.Carrito;
import com.example.sigloxxi.model.OrdenH;

import java.util.List;

public class BoletaAdapter extends BaseAdapter
{
    private Context context;
    private int layout;

    public BoletaAdapter(Context context, int layout) {
        this.context = context;
        this.layout = layout;
    }

    @Override
    public int getCount() {
        return 0;
    }

    @Override
    public Object getItem(int position) { return 0; }

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
            convertView = layoutInflater.inflate(R.layout.activity_boleta,null);
            holder = new ViewHolder();

            holder.boletaImageView = (ImageView) convertView.findViewById(R.id.imageView1);
            convertView.setTag(holder);
        }
        else{
            holder = (ViewHolder) convertView.getTag();
        }



        holder.boletaImageView.setImageResource(R.drawable.gracias);

        return convertView;
    }

    static class ViewHolder
    {
        private ImageView boletaImageView;
    }

}

