<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $taskRepository = $this->getDoctrine()->getRepository(Task::class); // Взимаме от базата
        $tasks = $taskRepository->findAll(); // Намира всички Tasks
        return $this->render(':task:index.html.twig', ['tasks' => $tasks]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $task = new Task();
        $form = $this->createForm(TaskType::class, $task);

        $form->handleRequest($request);
        if($form->isSubmitted() && $form->isValid()){
            if($task->getTitle() == null || $task->getComments() == null){
                return $this->redirectToRoute('create');
            }

            $em = $this->getDoctrine()->getManager();
            $em->persist($task); // Вземи от паметта и го натикай в базата данни
            $em->flush(); // save в базата

            return $this->redirectToRoute('index');
        }
        return $this->render(':task:create.html.twig', ['form' => $form->createView()]);
    }

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        $taskRepository = $this->getDoctrine()->getRepository(Task::class); // Взима от базата

        $task = $taskRepository->find($id); // Намира Task по ID

        if($task == null){
            return $this->redirectToRoute('index');
        }

        $form = $this->createForm(TaskType::class, $task); // Създаваме форма за това и я записваме в $task

        $form->handleRequest($request); // обработваме заявката

        if($form->isSubmitted() && $form->isValid()){

            $em = $this->getDoctrine()->getManager(); // Ползваме Entity Manager за да записваме, трием и т.н

            $em->remove($task); // Трием конкретния task, ползваме $em->persist($task) и за Edit
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render(':task:delete.html.twig',
            ['task' => $task, 'form' => $form->createView()]); // Подаваме Task и Form в инициативен масив
    }
}
