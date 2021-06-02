using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCreator : MonoBehaviour
{
    public GameObject pipe;

    private void Start()
    {
        StartCoroutine(generator());
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator generator()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            GameObject m_pipe = Instantiate(pipe, transform);
            m_pipe.GetComponent<Rigidbody2D>().velocity = new Vector2(-600, 0);
            int height = Random.Range(-3, 3);
            m_pipe.transform.localPosition = new Vector3(m_pipe.transform.localPosition.x, height * 200.0f, m_pipe.transform.localPosition.z);
            Destroy(m_pipe, 5);
            yield return new WaitForSeconds(1.5f);
        }
    }
}