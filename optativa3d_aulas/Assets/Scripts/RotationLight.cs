using UnityEngine;

public class MovimentoDoSol : MonoBehaviour
{
    public float cicloDia = 24f; // Duração do ciclo completo em segundos
    public AnimationCurve intensidadeLuzCurve; // Curva de intensidade da luz durante o ciclo
    public Light sol; // Referência à luz direcional

    private float tempoAtual = 0f; // Tempo decorrido no ciclo

    void Start()
    {
        if (sol == null)
        {
            sol = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Calcula o progresso no ciclo (0 a 1)
        tempoAtual += Time.deltaTime / cicloDia;
        if (tempoAtual > 1f) tempoAtual -= 1f;

        // Calcula o ângulo da rotação baseado no progresso
        float angulo = tempoAtual * 360f - 90f; // Inicia no horizonte
        transform.rotation = Quaternion.Euler(45, angulo, 90);

        // Ajusta a intensidade da luz com base na altura do sol
        if (intensidadeLuzCurve != null && sol != null)
        {
            float alturaNormalizada = Mathf.Clamp01((Mathf.Sin(tempoAtual * Mathf.PI * 2f) + 1f) / 2f);
            sol.intensity = intensidadeLuzCurve.Evaluate(alturaNormalizada);
        }
    }
}