package siglo21.springboot.backend.apirest.models.entity;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "CLIENTE")
public class Cliente implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@Column(name = "RUT")
	private int rut;

	@Column(name = "DV", nullable = false)
	private char dv;

	@Column(name = "NOMBRE", length = 70, nullable = false)
	private String nombre;

	@Column(name = "APELLIDO", length = 70, nullable = false)
	private String apellido;

	@Column(name = "CORREO", length = 255, nullable = false)
	private String correo;

	@Column(name = "TELEFONO", length = 255, nullable = false)
	private String telefono;

	public int getRut() {
		return rut;
	}

	public void setRut(int rut) {
		this.rut = rut;
	}

	public char getDv() {
		return dv;
	}

	public void setDv(char dv) {
		this.dv = dv;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getApellido() {
		return apellido;
	}

	public void setApellido(String apellido) {
		this.apellido = apellido;
	}

	public String getCorreo() {
		return correo;
	}

	public void setCorreo(String correo) {
		this.correo = correo;
	}

	public String getTelefono() {
		return telefono;
	}

	public void setTelefono(String telefono) {
		this.telefono = telefono;
	}

}
