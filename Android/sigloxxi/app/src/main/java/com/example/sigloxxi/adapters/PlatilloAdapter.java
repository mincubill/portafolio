package com.example.sigloxxi.adapters;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.sigloxxi.R;
import com.example.sigloxxi.helpers.carritoSQLiteHelper;
import com.example.sigloxxi.model.Carrito;
import com.example.sigloxxi.model.Platillo;

import java.util.ArrayList;
import java.util.List;

public class PlatilloAdapter extends BaseAdapter
{
    private Context context;
    private int layout;
    private List<Platillo> platillos;


    public PlatilloAdapter(Context context, int layout, List<Platillo> platillos) {
        this.context = context;
        this.layout = layout;
        this.platillos = platillos;
    }



    @Override
    public int getCount() {
        return this.platillos.size();
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
    public View getView(final int position, View convertView, ViewGroup parent)
    {
        //copiamos la vista
        ViewHolder holder ;
        final carritoSQLiteHelper caSQLiteHelper = new carritoSQLiteHelper(context,"dbtest1",null,1);
        final SQLiteDatabase db = caSQLiteHelper.getWritableDatabase();


        if(convertView == null)
        {
            //inflamos la vista que nos llega con nuestro loyout
            LayoutInflater layoutInflater = LayoutInflater.from(this.context);
            convertView = layoutInflater.inflate(R.layout.platillo_layout,null);
            holder = new ViewHolder();

            //referenciamos el elemento a modificar y lo rellenamos
            holder.platilloNombreTextView = (TextView) convertView.findViewById(R.id.platilloNombretxt);
            holder.platiloPrecioTextView =  (TextView) convertView.findViewById(R.id.platilloPreciotxt);
            holder.platilloimageView = (ImageView) convertView.findViewById(R.id.appIconIV);
            ImageButton button = (ImageButton) convertView.findViewById(R.id.moreImageButton);
            button.setOnClickListener(new View.OnClickListener() {
                public void onClick(View v) {
                    ArrayList<Carrito> ca= new ArrayList<Carrito>();
                    if(caSQLiteHelper.existeCarrito(platillos.get(position).getId(),db)==1)
                    {
                        caSQLiteHelper.updateCarrito(db,platillos.get(position).getId());
                        ca = (ArrayList<Carrito>) caSQLiteHelper.getAllCarrito(db);
                        for (Carrito car:ca) {
                            if(platillos.get(position).getId() == car.getPlatilloID()){
                                Toast.makeText(context, car.getNombre()+" x "+car.getCantidad(),Toast.LENGTH_SHORT).show();
                            }
                        }
                    }
                    else {
                        caSQLiteHelper.insertCarrito(platillos.get(position),1,db);
                        Toast.makeText(context, platillos.get(position).getNombre()+" x 1",Toast.LENGTH_SHORT).show();

                    }
                }
            });
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();

        }

        //nos traemos el valor segun la posicion
        String platilloNombre = platillos.get(position).getNombre().toLowerCase();
        String platilloPrecio = platillos.get(position).getTiempo() +" min";


        //rellenamos
        holder.platilloNombreTextView.setText(platilloNombre);
        holder.platiloPrecioTextView.setText(platilloPrecio);
        holder.platilloimageView.setImageResource(R.drawable.bar);


        return convertView;


    }

    static class ViewHolder
    {
        private  TextView platilloNombreTextView;
        private  TextView platiloPrecioTextView;
        private ImageView platilloimageView;
    }
}
