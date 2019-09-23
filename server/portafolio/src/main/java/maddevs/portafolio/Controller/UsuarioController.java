package maddevs.portafolio.Controller;

import java.util.Optional;

import maddevs.portafolio.DAO.UsuarioRepository;
import maddevs.portafolio.Entity.Usuario;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController

@RequestMapping("/usuario")
public class UsuarioController
{
    @Autowired
    private UsuarioRepository dao;

    @GetMapping("/")
    public String get()
    {
        throw  new RuntimeException("por lo menos aqui estoy");
    }

    @PostMapping("/add")
    public Usuario addCountry(@RequestBody Usuario usuario) {

        return dao.save(usuario);
    }

    @GetMapping("/all")
    public Iterable<Usuario> allUsuario() {
        System.out.println(dao.findAll());
        return dao.findAll();
    }

    @GetMapping("/{UsuarioId}")
    public Optional<Usuario> UsuarioById(@PathVariable("UsuarioId") int UsuarioId) {
        return dao.findById(UsuarioId);
    }

    @PutMapping("/update")
    public Usuario updateUsuario(@RequestBody Usuario usuario) {
        return dao.save(usuario);
    }

    @DeleteMapping("/{UsuarioId}")
    public void deleteUsuario(@PathVariable("UsuarioId") int UsuarioId) {
        dao.deleteById(UsuarioId);
    }
}


