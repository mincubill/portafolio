package siglo21.springboot.backend.apirest.models.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import siglo21.springboot.backend.apirest.models.dao.IMesaDao;
import siglo21.springboot.backend.apirest.models.entity.Mesa;

@Service
public class MesaServiceImpl implements IMesaService {

	@Autowired
	private IMesaDao mesaDao;

	@Override
	@Transactional(readOnly = true)
	public List<Mesa> findAll() {
		return (List<Mesa>) mesaDao.findAll();
	}

	@Override
	@Transactional(readOnly = true)
	public Mesa findById(int id) {
		return mesaDao.findById(id).orElse(null);
	}

	@Override
	@Transactional
	public Mesa save(Mesa mesa) {
		return mesaDao.save(mesa);
	}

	@Override
	@Transactional
	public void delete(int id) {
		mesaDao.deleteById(id);
	}

	@Override
	@Transactional
	public Mesa changeStatusAvailable(int id) {
		Mesa mesa = mesaDao.findById(id).orElse(null);
		if(mesa != null) {
			mesa.setEstado(1);
			return mesaDao.save(mesa);
		}
		return mesa;
	}

	@Override
	@Transactional
	public Mesa changeStatusNotAvailable(int id) {
		Mesa mesa = mesaDao.findById(id).orElse(null);
		if(mesa != null) {
			mesa.setEstado(2);
			return mesaDao.save(mesa);
		}
		return mesa;
	}
}
