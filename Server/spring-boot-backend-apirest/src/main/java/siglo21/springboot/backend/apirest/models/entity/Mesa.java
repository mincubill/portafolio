package siglo21.springboot.backend.apirest.models.entity;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "MESA")
public class Mesa implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@Column(name = "ID")
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Column(name = "NUMERO", nullable = false)
	private int numero;

	@Column(name = "CAPACIDAD", nullable = false)
	private int capacidad;

	@Column(name = "ESTADO", nullable = false)
	private int estado;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getNumero() {
		return numero;
	}

	public void setNumero(int numero) {
		this.numero = numero;
	}

	public int getCapacidad() {
		return capacidad;
	}

	public void setCapacidad(int capacidad) {
		this.capacidad = capacidad;
	}

<<<<<<< HEAD:Server/spring-boot-backend-apirest/src/main/java/siglo21/springboot/backend/apirest/models/entity/Mesa.java
=======
	public int getEstado() {
		return estado;
	}

	public void setEstado(int estado) {
		this.estado = estado;
	}

>>>>>>> QA:Server/spring-boot-backend-apirest/src/main/java/com/siglo21/springboot/backend/apirest/models/entity/Mesa.java
}
